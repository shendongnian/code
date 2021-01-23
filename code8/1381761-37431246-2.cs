          using (var builder = new AlertDialog.Builder(Activity))
          {
             var title = "Please edit your details:";
             builder.SetTitle(title);
             builder.SetPositiveButton("OK", OkAction);
             builder.SetNegativeButton("Cancel", CancelAction);
             var myCustomDialog = builder.Create();
             myCustomDialog.Show();
          }
          private void OkAction(object sender, DialogClickEventArgs e)
          {
             var myButton = sender as Button; //this will give you the OK button on the dialog but you're already in here so you don't really need it - just perform the action you want to do directly unless I'm missing something..
             if(myButton != null)
             {
                 //do something on ok selected
             }
          }
          private void CancelAction(object sender, DialogClickEventArgs e)
          {
             //do something on cancel selected
          }
