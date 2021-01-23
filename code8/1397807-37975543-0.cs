        private void ActualizarInsertarBandaMagnetica()
        {
            if (dgvBaseArchivo.Rows.Count <= 0)
            {
                MessageBox.Show("Primero carga el archivo", "Banco Azteca Cheques");
                return;
            }
            else
            {
                Ext_ChequesCollection objCheques = Ext_Cheques.GetAll();
                foreach(DataRow row in dtRegistrosTXT.Rows)
                {
                    Thread myThread = new Thread(() => this.BuscarCheque(row, objCheques));
                    myThread.Start();
                    Procesando++;
                }
                timerProcesar.Stop();
                FinProc = DateTime.Now;
                Invoke(new MethodInvoker(delegate
                {
                    cmdGuardar.Enabled = true;
                    cmdUploadFile.Enabled = true;
                }));
                MessageBox.Show("Proceso Finalizado", "Banco Azteca Cheques");
            }
        }
    
