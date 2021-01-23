    class DialogueTree {
       public void Execute()
       {
          int state = 0;
          while (state >= 0)
          {
             switch (state)
             {
                case 0:
                   state = this.State0();
                   break;
                case 1:
                   state = this.State1();
                   break;
                //and so on
             }
          }
       }
    }
