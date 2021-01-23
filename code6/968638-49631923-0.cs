    public IAlert WaitAlert(int timeOut)
        {
            for (int cont = timeOut; cont > 0; cont--)
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException erro)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
            }
            throw new NoAlertPresentException();
        }
