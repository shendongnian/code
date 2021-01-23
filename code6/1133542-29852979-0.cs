    var myAudio = new System.Web.UI.HtmlControls.HtmlAudio();
    myAudio.Attributes.Add("autoplay", "autoplay");
    myAudio.Attributes.Add("controls", "controls");
    myAudio.Src = "test.mp3";
    Form.Controls.Add(myAudio);
