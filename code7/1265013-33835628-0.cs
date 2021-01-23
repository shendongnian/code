           public interface  IPublisher 
           {
             event EventHandler OperationOccurred;
           }
          class ClassA : IPublisher
          {
              List<ClassB> Children;
              event EventHandler OperationOccurred;
             public ClassA()
              {
                  BroadCaster.Instance.RegisterPublisher(this);
              }
              protected virtual void OnOperationOccurred()
              {
                  if (OperationOccurred != null)
                      OperationOccurred(this, new EventArgs());
              }
          }
            class ClassB
            {
                List<ClassC> Grandchildren;
            }
            class ClassC
            {
              public ClassC()
                {
                    BroadCaster.Instance.BroadCastNotificaiton += Instance_OperationOccurred;
                }
              void Instance_OperationOccurred(object sender, EventArgs e)
              {
                  throw new NotImplementedException();
              }
            }
        /// <summary>
        /// A singleton class ... Like a  single braodcast tower just one in the city
        /// </summary>
        public sealed class BroadCaster
        {
            public static BroadCaster Instance { get; private set; }
            //Static constructor
            static BroadCaster()
            {
                Instance = new BroadCaster();
            }
            // private constructor 
            private BroadCaster(){}
            public event EventHandler BroadCastNotificaiton;
            public void RegisterPublisher(IPublisher publisher)
            {
                publisher.OperationOccurred += Publisher_OperationOccurred;
            }
            void Publisher_OperationOccurred(object sender, EventArgs e)
            {
                if (this.BroadCastNotificaiton != null)
                    this.BroadCastNotificaiton(sender, e);
            }
        }
