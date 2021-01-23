    using System.Windows.Controls;
    using MSHTML;
    
    namespace WPFCustomContextMenuInWebBrowser {
      public partial class MainWindow {
    
        public MainWindow() 
        {
          InitializeComponent();
          Browser.LoadCompleted += BrowserOnLoadCompleted;
        }
    
        void BrowserOnLoadCompleted(object sender, NavigationEventArgs navigationEventArgs)
        {
            var mshtmlDoc = Browser.Document as HTMLDocument;
            if (mshtmlDoc == null) return;
                        var doc2event = mshtmlDoc as HTMLDocumentEvents2_Event;
            if (doc2event != null)
            {               
                doc2event.onfocusin += FocusInContextMenu;
            }            
        }
 
        bool OpenContextMenu(IHTMLEventObj pEvtObj)
        {
            WbShowContextMenu(pEvtObj as ContextMenu);
            return false;
        }
        void FocusInContextMenu(IHTMLEventObj pevtobj)
        {
            var mshtmlDoc = Browser.Document as HTMLDocument;
            var doc2event = mshtmlDoc as HTMLDocumentEvents2_Event;
            if (doc2event != null)
            {
                doc2event.oncontextmenu -= OpenContextMenu;
                doc2event.onfocusin -= FocusInContextMenu;
                doc2event.oncontextmenu += OpenContextMenu;
                doc2event.onfocusin += FocusInContextMenu;
            }
        }
    
        public void WbShowContextMenu() 
        {
          ContextMenu cm = FindResource("MnuCustom") as ContextMenu;
          if (cm == null) return;
          cm.PlacementTarget = Browser;
          cm.IsOpen = true;
        }
      }
    }
