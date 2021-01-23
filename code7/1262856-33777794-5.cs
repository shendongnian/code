    public class EpisodeModel : IEpisodeModel
    {
        private bool loginPassed;
        public EpisodeModel()
        {
            if (Registry.GetValue("HKEY_CURRENT_USER", "URL", "") == null)
            {
                loginPassed = false;
            }
        }
        public bool LoginPassed
        {
            get
            {
                return this.loginPassed;
            }
        }
    }
