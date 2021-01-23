    using System.Linq;
    .....
    Button[] buttonArray = new Button[] {btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9};
    if(buttonArray.All(b => b.Text != string.Empty))
        MessageBox.Show("The game is a draw");
