    using System;
    using System.Collections.Generic;
    
    namespace UnitTestProject2
    {
    
        public class ViewModel1
        {
            IMediator mediator;
            public ViewModel1(IMediator mediator)
            {
                this.mediator = mediator;
            }
    
            public string UserId { get; set; }
            public void Login(string userid)
            {
                this.UserId = userid;
                this.mediator.RaiseEvent("LoggedIn", this.UserId);
            }
        }
    
        public class VieowModel2
        {
            IMediator mediator;
            public VieowModel2(IMediator mediator)
            {
                this.mediator = mediator;
                this.mediator.ListenFor("LoggedIn", LoggedIn);
            }
            protected string UserId;
            protected void LoggedIn(Object sender, EventArgs e)
            {
                UserId = sender.ToString();
            }
        }
    
        public interface IMediator
        {
            void ListenFor(string eventName, EventHandler action);
            void RaiseEvent(string eventName, object data);
        }
    }
