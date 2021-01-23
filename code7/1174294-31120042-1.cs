    using SpeechLib;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    private void button1_Click(object sender, EventArgs e)
            {
                SpSharedRecoContext spSharedRecoCtx = new SpSharedRecoContext();
                ISpeechRecognizer ispSpeechReco = spSharedRecoCtx.Recognizer;
                if (ispSpeechReco.IsUISupported("AddRemoveWord", null))
                {
                    ispSpeechReco.DisplayUI(this.Handle.ToInt32(), "Additional Training", "AddRemoveWord", "Example");
                }
            }
