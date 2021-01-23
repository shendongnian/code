    protected void Button1_Click(object sender, EventArgs e)
    
     {
                    Thread work1 = new Thread(new 
    
    ThreadStart(changestate1));
                            work1.Start();
    
                        Thread work2 = new Thread(new ThreadStart(changestate4));
                        work2.Start();
    
    
                        Thread work3 = new Thread(new ThreadStart(changestate7));
                        work3.Start();
    
                       **work1.Join();
                       work2.Join();
                       work3.Join();**
    
    
    
                    }
    
                    protected void changestate1()
                    {
                        Thread.Sleep(999);
                        TextBox1.Text = "Work1";
                        changestate2();
                    }
                    protected void changestate2()
                    {
                        Thread.Sleep(999);
                        TextBox2.Text = "Work1";
                        changestate3();
                    }
                    protected void changestate3()
                    {
                        Thread.Sleep(999);
                        TextBox3.Text = "Work1";
                    }
                    protected void changestate4()
                    {
                        Thread.Sleep(666);
                        TextBox4.Text = "Work2";
                        changestate5();
                    }
                    protected void changestate5()
                    {
                        Thread.Sleep(666);
                        TextBox5.Text = "Work2";
                        changestate6();
                    }
                    protected void changestate6()
                    {
                        Thread.Sleep(666);
                        TextBox6.Text = "Work2";
                    }
                    protected void changestate7()
                    {
                        Thread.Sleep(333);
                        TextBox7.Text = "Work3";
                        changestate8();
                    }
                    protected void changestate8()
                    {
                        Thread.Sleep(333);
                        TextBox8.Text = "Work3";
                        changestate9();
                    }
                    protected void changestate9()
                    {
                        Thread.Sleep(333);
                        TextBox9.Text = "Work3";
                    }
