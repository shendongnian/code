    foreach (var ticker in tickers)
    {
        tbOutput.Text += "Starting Download of : " + ticker + "\n";
        var url = string.Format(urlPrototype, ticker, startMonth, startDay, startYear, finishMonth, finishDay, finishYear, "d");
        var csvfile = directory + "\\" + ticker.ToUpper() + ".csv";
        
        ThreadPool.QueueUserWorkItem((o) =>
        {
            try
            {
                webClient.DownloadFile(url, csvfile);
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    //do something or output like
                    tbOutput.Text += "End Download of : " + ticker + " (OK)\n";
                }));
            }
            catch (Exception ex)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                   //do something or output like
                   tbOutput.Text += "End Download of : " + ticker + " (FAIL)\n";
                }));
            }
            finally
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    //do something or output like
                    //tbOutput.Text += "End Download of : " + ticker + "\n";
                }));
            }
        }
    }
