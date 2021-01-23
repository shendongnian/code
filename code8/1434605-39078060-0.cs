     if (NewDescription.Contains("{objectname}") )
        {
           NewDescription = NewDescription.Replace("{objectname}", objectName);
        }
        else if(NewDescription.Contains("{inputvalue}"))
        {
        NewDescription = NewDescription.Replace("{inputvalue}", inputValue);
        }
        else if(NewDescription.Contains("{expectedvalue}"))
        {
        NewDescription = NewDescription.Replace("{expectedvalue}", expectedValue);
        }
            else
       label.Text="Wrong format";
        				
