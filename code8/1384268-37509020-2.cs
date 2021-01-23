    delegate void MyDelegate();// This is defined in my delegate handler class where ComposeDelegates is
      void ComposeDelegates()
            {
                var c = Delegate.Combine(destroy,showPoints);
                c = Delegate.Remove(c ,showPoints);
                c();// This calls the functions asociated with the destroy and showPoints delegates.
            }
    void ComposeDelegates()// This works as expected;
    {
       switch(type)
        {
            case BehaviourType.JustDestroy:
                c = (MyDelegate)Delegate.Combine(c,destroy);
                break;
            case BehaviourType.DestroyAndShowPoints:
                c = (MyDelegate)Delegate.Combine(destroy,showPoints);        break;
            case BehaviourType.ShowPoints:
                c=  (MyDelegate)Delegate.Combine(c,showPoints);
                break;
        }
        c();  
    }
    void AnotherWayToComposeDelegates()// This works as well.
        {
            c = (MyDelegate)Delegate.Combine(destroy,showPoints); 
            //Lets say I want to remove showPoints;
            if (type == BehaviourType.JustDestroy)
            {
                c =(MyDelegate) Delegate.Remove(c, showPoints); ;
            }
            c();
        }
    }
