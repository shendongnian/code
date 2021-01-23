     public void InstallService(string ExeFilename)
            {
                try
                {
                    System.Configuration.Install.AssemblyInstaller Installer = new System.Configuration.Install.AssemblyInstaller(ExeFilename, null);
                    Installer.UseNewContext = true;
                    Installer.Install(null);
                    Installer.Commit(null);
                    DialogResult NovoDialog = new DialogResult();
                    NovoDialog = MessageBox.Show("Deseja Iniciar o Serviço?", "Orca ++ Updater", MessageBoxButtons.YesNo);
                    if (NovoDialog == DialogResult.Yes)
                    {
                        ServiceController service = new ServiceController("OrcaService");
                        TimeSpan timeout = TimeSpan.FromMilliseconds(1500);
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
    
                    }
                }
                catch (Exception ex)
                {
                    Erro NovoErro = new Erro();
                    Program.Erro = ex.ToString();
                    NovoErro.ShowDialog();
                }
            }
