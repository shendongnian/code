    private void Form1_Click(object sender, EventArgs e)
    {
      var p = PointToClient(Cursor.Position);
      var control = GetChildAtPoint(p);
      if(control is Button)
      {
         var buttonText = ((Button)control).Text;
         //Query using buttonText
      }
    }
