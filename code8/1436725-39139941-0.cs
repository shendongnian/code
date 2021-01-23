    public override void Uninstall(IDictionary savedState)
    {
        this.PrintStartText(Res.GetString("InstallActivityUninstalling"));
        if (!this.initialized)
        {
            this.InitializeFromAssembly();
        }
        string installStatePath = this.GetInstallStatePath(this.Path);
        if ((installStatePath != null) && File.Exists(installStatePath))
        {
            FileStream input = new FileStream(installStatePath, FileMode.Open, FileAccess.Read);
            XmlReaderSettings settings = new XmlReaderSettings {
                CheckCharacters = false,
                CloseInput = false
            };
            XmlReader reader = null;
            if (input != null)
            {
                reader = XmlReader.Create(input, settings);
            }
            try
            {
                if (reader != null)
                {
                    NetDataContractSerializer serializer = new NetDataContractSerializer();
                    savedState = (Hashtable) serializer.ReadObject(reader);
                }
                goto Label_00C6;
            }
            catch
            {
                object[] args = new object[] { this.Path, installStatePath };
                base.Context.LogMessage(Res.GetString("InstallSavedStateFileCorruptedWarning", args));
                savedState = null;
                goto Label_00C6;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (input != null)
                {
                    input.Close();
                }
            }
        }
        savedState = null;
    Label_00C6:
        base.Uninstall(savedState);
        if ((installStatePath != null) && (installStatePath.Length != 0))
        {
            try
            {
                File.Delete(installStatePath);
            }
            catch
            {
                object[] objArray2 = new object[] { installStatePath };
                throw new InvalidOperationException(Res.GetString("InstallUnableDeleteFile", objArray2));
            }
        }
    }
