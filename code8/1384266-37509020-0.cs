    delegate void MyDelegate();// This is defined in my delegate handler class where ComposeDelegates is
      void ComposeDelegates()
            {
                MyDelegate c = new Delegate.Combine(destroy,showPoints);
                c = Delegate.Remove(c ,showPoints);
                c();// This calls the functions asociated with the destroy and showPoints delegates.
            }
    void ComposeDelegates()// This works as expected;
    {
       switch(type)
        {
            case BehaviourType.JustDestroy:
                c = Delegate.Combine(c,destroy);
                break;
            case BehaviourType.DestroyAndShowPoints:
                c = Delegate.Combine(destroy,showPoints);        break;
            case BehaviourType.ShowPoints:
                c=  Delegate.Combine(c,showPoints);
                break;
        }
        c();  
    }
    void AnotherWayToComposeDelegates()// This works as well.
        {
            c = Delegate.Combine(destroy,showPoints); 
            //Lets say I want to remove showPoints;
            if (type == BehaviourType.JustDestroy)
            {
                c = Delegate.Remove(c, showPoints); ;
            }
            c();
        }
    }
