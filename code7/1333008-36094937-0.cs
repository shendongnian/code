    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Configuration;
    public partial class Skins_DownloadGridView : System.Web.UI.UserControl
    {
        private const string CtlIdent = "Controls_DownloadGridView";
        private string _Cat = "NONE";
        private string _SubCat = "";
        private string _SubCatHeader;
        private string _FileNameHeader;
        private string _FileDescHeader;
        private string _ActionsHeader;
        private bool _debug = false;
        private bool _enabled = false;
        private UCLA.EOL.UI.Web.GVUtility GVUtil = new UCLA.EOL.UI.Web.GVUtility();
        protected override object SaveViewState()
        {
            UCLA.EOL.Common.Logging.LogDebug(string.Format("{0}.SaveViewState", CtlIdent), UCLA.EOL.Common.Constants.DebugCodes.UserControls);
            object VS_base = base.SaveViewState();
            object[] VS_all = new object[9];
            VS_all[0] = VS_base;
            VS_all[1] = _Cat;
            VS_all[2] = _SubCat;
            VS_all[3] = _SubCatHeader;
            VS_all[4] = _FileNameHeader;
            VS_all[5] = _FileDescHeader;
            VS_all[6] = _ActionsHeader;
            VS_all[7] = _debug;
            VS_all[8] = _enabled;
            
			//return VS_all;
			return new Pair(VS_base, VS_all); // <-- Change
        }
        protected override void LoadViewState(object VS_saved)
        {
            UCLA.EOL.Common.Logging.LogDebug(string.Format("{0}.LoadViewState", CtlIdent), UCLA.EOL.Common.Constants.DebugCodes.UserControls);
            if ((VS_saved != null))
            {
                object[] VS_all = new object[]{VS_saved};
                
				// *** CHANGE START ***
				
				Pair pair = (Pair)VS_saved;
                if ((VS_all[0] != null))
                    base.LoadViewState(pair.First);
                VS_all = (Object[])pair.Second;
				
				// *** CHANGE  END  ***                
				
				if ((VS_all[1] != null))
                    _Cat = Convert.ToString(VS_all[1]);
                if ((VS_all[2] != null))
                    _SubCat = Convert.ToString(VS_all[2]);
                if ((VS_all[3] != null))
                    _SubCatHeader = Convert.ToString(VS_all[3]);
                if ((VS_all[4] != null))
                    _FileNameHeader = Convert.ToString(VS_all[4]);
                if ((VS_all[5] != null))
                    _FileDescHeader = Convert.ToString(VS_all[5]);
                if ((VS_all[6] != null))
                    _ActionsHeader = Convert.ToString(VS_all[6]);
                if ((VS_all[7] != null))
                    _debug = Convert.ToBoolean(VS_all[7]);
                if ((VS_all[8] != null))
                    Enabled = Convert.ToBoolean(VS_all[8]);
            }
        }
    }
