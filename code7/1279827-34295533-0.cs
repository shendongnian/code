    public partial class CreateDevice : Form
    {
        static void Main()
        {
            CreateDevice frm = new CreateDevice();
            Application.Run(frm);
        }
        public CreateDevice()
        {
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "D3D Tutorial 01: CreateDevice";
        }
    }
