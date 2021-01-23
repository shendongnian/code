    using System;
    using System.Collections.Generic;
    
    namespace NatWa.MidOffice.CustomControls.Wizard
    {
        public class WizardTransitionMap : Dictionary<Type, Dictionary<Type, Delegate>>
        {
            public void Add<TCurrentScreenType, TNextScreenType>(Delegate delegateFactory)
            {
                if (!ContainsKey(typeof(TCurrentScreenType)))
                {
                    Add(typeof(TCurrentScreenType), new Dictionary<Type, Delegate> { { typeof(TNextScreenType), delegateFactory } });
                }
                else
                {
                    this[typeof(TCurrentScreenType)].Add(typeof(TNextScreenType), delegateFactory);
                }
            }
    
            public IWizardScreen GetNextScreen(IWizardScreen screenThatClosed)
            {
                var identity = screenThatClosed.GetType();
                var state = screenThatClosed.State;
                var transition = screenThatClosed.NextScreenType;
    
                if (!ContainsKey(identity))
                {
                    throw new InvalidOperationException(String.Format("There are no states transitions defined for state {0}", identity));
                }
    
                if (!this[identity].ContainsKey(transition))
                {
                    throw new InvalidOperationException(String.Format("There is no response setup for transition {0} from screen {1}", transition, identity));
                }
    
                if (this[identity][transition] == null)
                    return null;
    
                return (IWizardScreen)this[identity][transition].DynamicInvoke(state);
            }
        }
    }
