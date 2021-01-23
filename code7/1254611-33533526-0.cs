        public static void InitGrowTimer(int time, string name)
        {
            growTimer = new System.Threading.Timer(growTimer_Finished, null, time, Timeout.Infinite);
            currentPlant = name;
        }
        private static void growTimer_Finished(object sender)
        {
            MessageBox.Show("Your " + currentPlant + " is finished!", "Civilisation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
