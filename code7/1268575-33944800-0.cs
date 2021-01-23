      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Reflection;
    
      public abstract class RegistrationBusBase
      {
        protected readonly Dictionary<Type, Dictionary<Guid, Action<IMessage>>> routes = new Dictionary<Type, Dictionary<Guid, Action<IMessage>>>();
        
        private static MethodInfo createActionMethod;
        private static MethodInfo registerMethod;
    
        /// <summary>
        /// Subscribes all IEventHandler derivations located in the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to search for IEventHandler derivations.</param>
        /// <param name="eventsHandlerFactory">A factory capable of producing a concrete implementation of each IEventHandler.</param>
        public static void Subscribe(IBus bus, Assembly assembly, Func<Type, IEventsHandler> eventsHandlerFactory)
        {
          IEnumerable<Type> handlers = assembly.GetExportedTypes().Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IEventHandler<>)));
          foreach (Type handlerType in handlers)
          {
            IEventsHandler eventsHandler = eventsHandlerFactory(handlerType);
            if (eventsHandler == null)
            {
              throw new InvalidOperationException(string.Format("No handler for {0} found in the eventsHandlerFactory", handlerType.FullName));
            }
            else
            {
              bus.Subscribe(eventsHandler);
            }
          }
        }
    
        public void RegisterCommandHandler<T>(Action<T> handler, SubscriptionDisposer subscriptionDisposer) where T : ICommand
        {
          this.RegisterHandler<T>(handler, subscriptionDisposer);
        }
    
        public void RegisterEventHandler<T>(Action<T> handler, SubscriptionDisposer subscriptionDisposer) where T : IDomainEvent
        {
          this.RegisterHandler<T>(handler, subscriptionDisposer);
        }
    
        public Action<TEvent> CreatePublishAction<TEvent, TEventHandler>(TEventHandler eventHandler)
          where TEvent : IDomainEvent
          where TEventHandler : IEventHandler<TEvent>
        {
          return eventHandler.Handle;
        }
    
        public Action<TCommand> CreateSendAction<TCommand, TCommandHandler>(TCommandHandler commandHandler)
          where TCommand : ICommand
          where TCommandHandler : ICommandHandler<TCommand>
        {
          return commandHandler.Handle;
        }
    
        public IDisposable Subscribe<M>(Action<M> subscription)
        {
          throw new NotImplementedException();
        }
    
        public abstract IDisposable Subscribe(object subscriber);
    
        internal void DeregisterHandler(Type type, Guid handler)
        {
          Dictionary<Guid, Action<IMessage>> handlers;
          if (this.routes.TryGetValue(type, out handlers))
          {
            handlers.Remove(handler);
          }
        }
    
        protected IDisposable RegisterAllHandlersByReflection(object eventHandler)
        {
          SubscriptionDisposer subscriptionDisposer = new SubscriptionDisposer(this);
          this.RegisterAllEventHandlersByReflection(eventHandler, subscriptionDisposer);
          this.RegisterAllCommandHandlersByReflection(eventHandler, subscriptionDisposer);
          return subscriptionDisposer;
        }
    
        private void RegisterHandler<T>(Action<T> handler, SubscriptionDisposer subscriptionDisposer) where T : IMessage
        {
          Dictionary<Guid, Action<IMessage>> handlers;
          if (!this.routes.TryGetValue(typeof(T), out handlers))
          {
            handlers = new Dictionary<Guid, Action<IMessage>>();
            this.routes.Add(typeof(T), handlers);
          }
    
          Guid handlerID = Guid.NewGuid();
          Action<IMessage> adjustedHandler = DelegateAdjuster.CastArgument<IMessage, T>(x => handler(x));
          handlers.Add(handlerID, adjustedHandler);
          subscriptionDisposer.AddHandler(typeof(T), handlerID);
        }
    
        private void RegisterAllEventHandlersByReflection(object eventHandler, SubscriptionDisposer subscriptionDisposer)
        {
          IEnumerable<Type> handleEventTypes = eventHandler.GetType().GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEventHandler<>));
          foreach (Type handleEventType in handleEventTypes)
          {
            this.RegisterEventHandler(handleEventType, eventHandler, subscriptionDisposer);
          }
        }
    
        private void RegisterAllCommandHandlersByReflection(object handler, SubscriptionDisposer subscriptionDisposer)
        {
          IEnumerable<Type> handlerTypes = handler.GetType().GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
          foreach (Type handlerType in handlerTypes)
          {
            this.RegisterCommandHandler(handlerType, handler, subscriptionDisposer);
          }
        }
    
        private void RegisterEventHandler(Type handleEventType, object eventHandler, SubscriptionDisposer subscriptionDisposer)
        {
          createActionMethod = this.GetType().GetMethod("CreatePublishAction");
          registerMethod = this.GetType().GetMethod("RegisterEventHandler");
          var genericArgs = handleEventType.GetGenericArguments();
          foreach (var genericArg in genericArgs)
          {
            var action = this.CreateTheProperAction(genericArg, eventHandler);
            this.RegisterTheCreatedAction(genericArg, action, subscriptionDisposer);
          }
        }
    
        private void RegisterCommandHandler(Type handleEventType, object eventHandler, SubscriptionDisposer subscriptionDisposer)
        {
          createActionMethod = this.GetType().GetMethod("CreateSendAction");
          registerMethod = this.GetType().GetMethod("RegisterCommandHandler");
          var genericArgs = handleEventType.GetGenericArguments();
          foreach (var genericArg in genericArgs)
          {
            var action = this.CreateTheProperAction(genericArg, eventHandler);
            this.RegisterTheCreatedAction(genericArg, action, subscriptionDisposer);
          }
        }
    
        private void RegisterTheCreatedAction(Type handlerType, object action, SubscriptionDisposer subscriptionDisposer)
        {
          registerMethod.MakeGenericMethod(handlerType).Invoke(this, new[]
          {
            action,
            subscriptionDisposer
          });
        }
    
        private object CreateTheProperAction(Type handlerType, object handler)
        {
          return createActionMethod.MakeGenericMethod(handlerType, handler.GetType()).Invoke(this, new[] { handler });
        }
      }
     
