    using System.Threading.Tasks;
    async void YourFunction()   // <--- Use "async" keyword
    {
        switch (colorNum)
        {
            case 1:
                btnRed.BackColor = Color.Red;
                await Task.Delay(2000);
                btnRed.BackColor = Color.LightCoral;
                firedColors[count] = "Red";
                count++;
                break;
            case 2:
                btnBlue.BackColor = Color.Blue;
                await Task.Delay(2000);
                btnRed.BackColor = Color.LightBlue;
                firedColors[count] = "Blue";
                count++;
                break;
            case 3:
                btnYellow.BackColor = Color.Gold;
                await Task.Delay(2000);
                btnYellow.BackColor = Color.LightYellow;
                firedColors[count] = "Yellow";
                count++;
                break;
        }
    }
