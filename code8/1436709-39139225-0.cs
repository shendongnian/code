    /// <summary>
        /// Datenbank wird geöffnet.
        /// </summary>
        /// <param name="sCon">Verbindungsstring.</param>
        /// <returns>Erfolgreich?</returns>
        public bool OpenDBConnect(string sCon)
        {
            bool bOK = false;
            try
            {
                _conn = new SqlConnection(sCon);
                _sConn = sCon;
                _conn.Open();
                bOK = true;
            }
            catch (Exception ex)
            {
                _Logger.Log(Properties.EnglishStringResource.ConnectionFailed + ex.Message);                
                bOK = false;
            }
            return bOK;
        }
