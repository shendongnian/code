    private void AddReservationButtonClick(object sender, EventArgs e)
    {
         var intent = new Intent(this, typeof(AddReservationActivity));
         StartActivityForResult(intent, 1000); // 1000 is just a random number, though it needs to match the value in OnActivityResult
    }
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
         if (resultCode == Result.Cancelled)
         {
            // user cancelled the reservation add, so don't refresh
            return;
         }
         if (requestCode == 1000)
         {
             RefreshReservationData();
         }
    }
