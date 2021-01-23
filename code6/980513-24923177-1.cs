        private void logMessage(object parameters)
        {
            object[] Paras = (object[])parameters;
            int level = Convert.ToInt32(Paras[0]);
            string message = (string)(Paras[1]);
            DataRow row = Logs.NewRow();
            row["Level"] = level;
            row["Message"] = message;
            Logs.Rows.Add(row);
        }
        public void LogMessage(int level, string message)
        {
            object lvl = Convert.ToString(level);
            object msg = message;
            object[] ob = { lvl, msg };
            if (Util.client.player.isRunning)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ParameterizedThreadStart(logMessage), ob);
                ParameterizedThreadStart pts = new ParameterizedThreadStart(logMessage);
            }
        }
