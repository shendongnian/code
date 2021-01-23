    private void bwAsync_DoWork(object sender, DoWorkEventArgs e)
	{
		// The sender is the BackgroundWorker object we need it to
		// report progress and check for cancellation.
		BackgroundWorker bwAsync = sender as BackgroundWorker;
        if(!bwAsync.CancellationPending)
        {
			//Criar o Backup dos ficheiros do cliente e do serviço antigo
			UpdateMessage("A criar backup dos ficheiros de Cliente");
			Program.Funcoes.DirectoryCopy(Global.OldClient, textBoxBackup.Text + "\\OrcaClientBackup", true, true);
			bwAsync.ReportProgress(10);
        }
        if(!bwAsync.CancellationPending)
        {			
			UpdateMessage("A criar backup dos ficheiros do Serviço");
			Program.Funcoes.DirectoryCopy(Global.OldService, textBoxBackup.Text + "\\OrcaServiceBackup", true, true);
			bwAsync.ReportProgress(15);
        }
			
        if(!bwAsync.CancellationPending)
        {
			////A Parar e desinstalar o Serviço Actual
			UpdateMessage("A parar o Serviço existente");
			Program.Funcoes.StopService("OrcaService", 1000, true);
			bwAsync.ReportProgress(20);
        }
			
        if(!bwAsync.CancellationPending)
        {
			//Eliminar os ficheiros do Serviço Antigo
			UpdateMessage("A preparar os ficheiros para actualizar o cliente");
			//Program.Funcoes.DeleteAll(Global.OldService);
			bwAsync.ReportProgress(30);
        }
			
        if(!bwAsync.CancellationPending)
        {
			//Eliminar os ficheiros do Serviço Antigo
			//Program.Funcoes.DeleteAll(Global.OldClient);
			UpdateMessage("A preparar os ficheiros para actualizar o serviço");
			bwAsync.ReportProgress(40);
        }
			
        if(!bwAsync.CancellationPending)
        {
			//Copiar os Novos Ficheiros
			UpdateMessage("A actualizar o Cliente");
			Program.Funcoes.DirectoryCopy(Global.NovoCliente, Global.OldClient, true, false);
			bwAsync.ReportProgress(50);
        }
			
        if(!bwAsync.CancellationPending)
        {
			UpdateMessage("A actualizar o Serviço");
			Program.Funcoes.DirectoryCopy(Global.NovoServiço, Global.OldService, true, false);
			bwAsync.ReportProgress(55);
        }
			
        if(!bwAsync.CancellationPending)
        {
			//Fazer as alterações ao Orca.config.exe
			UpdateMessage("A configurar o Cliente");
			WriteConfigOrca(Global.OldClient);
			Program.Funcoes.UpdateCliente(Global.OldClient + @"\Orca.exe.config", Global.NovoCliente + @"\Orca.exe.config");
			bwAsync.ReportProgress(70);
        }
        if(!bwAsync.CancellationPending)
        {			
			UpdateMessage("A configurar o Serviço");
			Program.Funcoes.UpdateService(Global.OldService + @"\OrcaService.exe.config", Global.NovoServiço + @"\OrcaService.exe.config");
			//WriteConfigOrcaService(Program.OldService + "\\OrcaService.exe.config");
			bwAsync.ReportProgress(85);
        }
			
        if(!bwAsync.CancellationPending)
        {
			//Instalar o serviço
			UpdateMessage("A instalar o novo Serviço");
			Program.Funcoes.InstallService(Global.OldService + "\\OrcaService.exe");
			Thread.Sleep(100);
			bwAsync.ReportProgress(100);
        }
		return;
	}
