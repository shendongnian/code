    public partial class CarForm : Form
    {
        private Car theCar;
        private bool modelChanged;
        public CarForm()
        {
            theCar = new Car();
            InitializeComponent();
            loadChangeSpeed_cb();
            loadTopSpeed_cb();
            modelChanged = false;
        }
        private void loadChangeSpeed_cb()
        {
            for (decimal i = 1; i <= 200; i++)
            {
                changeSpeed_cb.Items.Add(i);
            }
        }
        private void loadTopSpeed_cb()
        {
            for(decimal i = 60; i <= 200; i+=10)
            {
                topSpeed_cb.Items.Add(i);
            }
        }
        private void accel_b_Click(object sender, EventArgs e)
        {
            if(modelChanged)
            {
                theCar.CurrentSpeed = theCar.ChangeSpeed;
                modelChanged = false;
            }
            else
            {
                var si = changeSpeed_cb.SelectedItem;
                if (si == null)
                {
                    return;
                }
                theCar.Accelerate((decimal)si);
            }
        }
        private void decel_b_Click(object sender, EventArgs e)
        {
            if(modelChanged)
            {
                theCar.CurrentSpeed = 0;
                modelChanged = false;
                return;
            }
            else
            {
                var si = changeSpeed_cb.SelectedItem;
                if (si == null)
                {
                    return;
                }
                theCar.Accelerate(-(decimal)si);
            }
        }
        private void topSpeed_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var si = topSpeed_cb.SelectedItem;
            if(si == null)
            {
                return;
            }
            theCar.TopSpeed = (decimal)si;
        }
        private void changeSpeed_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var si = changeSpeed_cb.SelectedItem;
            if (si == null)
            {
                return;
            }
            theCar.ChangeSpeed = (decimal)changeSpeed_cb.SelectedItem;
        }
  
