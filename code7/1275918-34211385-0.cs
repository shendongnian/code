            public void waitForElement()
        {
            while(!yourDialogElement.Displayed)
            {
                yourButtonElement.Click()
                System.Threading.Thread.Sleep(1000) // sleep for 1000 milliseconds
                
            }
        }
