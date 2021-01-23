      public class TreeModifier
      {
           private ITreeUIOutput _ui;
           public TreeModifier(ITreeUIOutput ui)
           {
                _ui = ui;
           }
           public void AfterSelect(string nodeName, string nodeText)
           {
                _ui.ChangeLabel(nodeName, nodeText + "New");
           }
      }
