        public static void InitGrowTimer(int time, string name)
        {
            growTimer = new System.Threading.Timer(GrowTimer_Finished, null, time, Timeout.Infinite);
            currentPlant = name;
        }
        private static void GrowTimer_Finished(object sender)
        {
            MessageBox.Show("Your " + currentPlant + " is finished!", "Civilisation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
