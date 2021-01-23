    using System.Windows.Controls;
    using MSHTML;
    
    namespace WPFCustomContextMenuInWebBrowser {
      public partial class MainWindow {
        private HTMLDocumentEvents2_Event _docEvent;
        public MainWindow() {
          InitializeComponent();
          Wb.Navigate("http://google.com");
          Wb.LoadCompleted += delegate {
            if (_docEvent != null) {
              _docEvent.oncontextmenu -= _docEvent_oncontextmenu;
            }
            if (Wb.Document != null) {
              _docEvent = (HTMLDocumentEvents2_Event)Wb.Document;
              _docEvent.oncontextmenu += _docEvent_oncontextmenu;
            }
          };
        }
    
        bool _docEvent_oncontextmenu(IHTMLEventObj pEvtObj) {
          WbShowContextMenu();
          return false;
        }
    
        public void WbShowContextMenu() {
          ContextMenu cm = FindResource("MnuCustom") as ContextMenu;
          if (cm == null) return;
          cm.PlacementTarget = Wb;
          cm.IsOpen = true;
        }
      }
    }
