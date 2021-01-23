    public void ChangeImage(object sender, CommandEventArgs e)
    {
          ImageButton imageButton = sender as ImageButton;
          string imageToChange = e.CommandArgument;
          //Then you can assign the appropreate image
          imageButton.ImageUrl = "~/Images/Penguins.jpg";
       
    }
