    public class ParentForm: Form
        {
            PictureBox pBoxMale { get; set; }
    
            PictureBox pBoxFemale { get; set; }
    
            public void changeVisiblity(int column, DataRow dRow) // Change profile gender icon's visibility
            {
                string tempGender = dRow.ItemArray.GetValue(column).ToString();
                if (tempGender == "M")
                {
                    pBoxMale.Visible = true;
                }
                else
                {
                    pBoxFemale.Visible = true;
                }
            }
        }
