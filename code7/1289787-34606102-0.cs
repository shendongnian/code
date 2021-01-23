    public void OnOperatorBtnClick(object sender, RoutedEventArgs args)
    {
        Button operatorBtnClick = (Button)sender;
        EqualsRepeated = false;
        if (isOperationPerformed == false)
        {
            if (xResultNumber != 0)
            {
                OnEqualsBtnClick(this, new RoutedEventArgs());
                operationPerformed = (string)operatorBtnClick.Content;
                isOperationPerformed = true;
                EqualsRepeated = false;
            }
            else
            {
                operationPerformed = (string)operatorBtnClick.Content;
                xResultNumber = Double.Parse(OutputValue);
                isOperationPerformed = true;
            }
        }
        else
        {
            //Do nothing. 
        }
    }
    public void OnEqualsBtnClick(object sender, RoutedEventArgs args)
    {
        if (EqualsRepeated == false)
        {
            if (double.TryParse(OutputValue, out yResultNumber))
                switch (operationPerformed)
                {
                    case "+":
                        {
                            OutputValue = (xResultNumber + yResultNumber).ToString();
                            break;
                        }
                }
            isOperationPerformed = true;
            EqualsRepeated = true;
        }
        else
        {
            // If equals has already been clicked
            if (EqualsRepeated == true)
                if (double.TryParse(OutputValue, out xResultNumber))
                    switch (operationPerformed)
                    {
                        case "+":
                            {
                                OutputValue = (xResultNumber + yResultNumber).ToString();
                                break;
                            }
                    }
        }
        isOperationPerformed = false;
        xResultNumber = 0;
    }
