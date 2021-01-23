    //make your dialog as global
    Dialog alertDialog;
    
    //your OnCreate() method
    protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
    
            SetContentView(Resource.Layout.Main);
    
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            //now when you click on the button,dialog will appear with button OK(if you click on OK,dialog will disappear)
            button.Click += delegate {
    
                var builder = new AlertDialog.Builder(_context);
                            builder.SetTitle("Titolo");
    
                            builder.SetMessage("Test this example");
                            builder.SetCancelable(false);
    
                            builder.SetPositiveButton("OK", new EventHandler<DialogClickEventArgs>((sender1, e2) =>
                                { 
                                    alertDialog.Dismiss();
                                }));
                            alertDialog = builder.Create();
                            alertDialog.SetCanceledOnTouchOutside(false);
                            alertDialog.Show();
    
            };
        } 
 
