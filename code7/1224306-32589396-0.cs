    public partial class Form1 : Form { public Form1() { InitializeComponent(); }
    private bool isDoorLocked =true;
    private bool isDogHome =true;
    private void btLock_Click(object sender, EventArgs e)
    {
        lbDoor.Text = "Door is now locked!";
        isDoorLocked = true;
    }
    private void btUnlock_Click(object sender, EventArgs e)
    {
        lbDoor.Text = "Door is now unlocked!";
        isDoorLocked = false;
    }
    private void btDogIsHome_Click(object sender, EventArgs e)
    {
        lbDog.Text = "Dog is home!";
        isDogHome= true;
    }
    private void btDogIsNotHome_Click(object sender, EventArgs e)
    {
        lbDog.Text = "Dog is not home!";
        isDogHome = false;
    }
    private void btShowRisk_Click(object sender, EventArgs e)
    {    
        if (!isDogHome && !isDoorLocked )
        {
            lbDisplayRisk.Text = "Thieves might break into the house!";
        }
        else 
        {
            lbDisplayRisk.Text = "The house is secure!";
        }
    }
    }
