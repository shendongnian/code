    public class PersistentOpenFileDialog
    {
		OpenFileDialog m_ofd = new OpenFileDialog();
		string m_persistentDirectory = null;
		public PersistentOpenFileDialog()
		{
			m_ofd.CheckFileExists = true;
			m_ofd.CheckPathExists = true;
			m_ofd.ReadOnlyChecked = true;
		}
		public bool? ShowDialog()
		{
			if (m_persistentDirectory != null)
			{
				m_ofd.InitialDirectory = m_persistentDirectory;
			}
			bool? retval = m_ofd.ShowDialog();
			if (retval == true)
			{
				m_persistentDirectory = new FileInfo(FileName).DirectoryName;
			}
			return retval;
		}
		public string FileName
		{
			get { return m_ofd.FileName; }
			set { m_ofd.FileName = value; }
		}
    }
