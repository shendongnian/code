    enter code here
       private void Invoke()
        {
            for (int i = I; Condition.Invoke(i); i += Increment)
            {
                Action.Invoke(i);
                if(i.Equals(9))
                break;
            }
        }
