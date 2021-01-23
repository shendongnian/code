    private void InitializeTimer()
    {
        var confcontr = new ConfigurationController();
        var config = confcontr.ReadConfiguration();
        try
        {
            if (serviceTimer == null)
            {
                serviceTimer = new System.Timers.Timer();
                serviceTimer.AutoReset = true;
                Articles art = new Articles(config);
                //Conexion a a los articulos de BD para obtener parametros de iniciación 
                serviceTimer.Interval = Convert.ToDouble(60 * 1000) * art.Parameter();
                //Se especifica cada que tanto tiempo se ejecuta el servicio
                serviceTimer.Elapsed += serviceTimer_Elapsed;
                serviceTimer.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Log.Instance.WriteToLog(ex.Message + ex.StackTrace + "initializetimer");
        }
    }
    protected void serviceTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        serviceTimer.Enabled = false;
        try
        {
            var artcont = new ArticulosController();
            artcont.EjecutarArticulo();
        }
        catch (Exception ex)
        {
            Log.Instance.WriteToLog(ex.Message + ex.StackTrace + "serviceTimer_Elapsed");
        }
        serviceTimer.Enabled = true;
    }
