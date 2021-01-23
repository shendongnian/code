    Task.Factory.StartNew(()=>
                {
                    //Call your methods 
                    //Method1();
                    //then you need to call dispatcher to update the progress bar value because you are using a different Thread 
                    Application.Current.Dispatcher.Invoke(()=>{ progressBar.Value += 1;});
                    //Method2();
                });
