    private void DoSomething(int i)
    {
        //Rest of Logic
    }
    
    public void SwitchMethod(char input)
    {
        int i = 0;
        Switch (input)
        {
            case 'A': 
                break;
            case 'B':
                i = 5;
                DoSomething(i);
                break;
            case 'C':
                i = 10;
                DoSomething(i);
                break;
        }
    }
