      protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnSelectPhoto.Attributes.Add("data-toggle", "modal");
            btnSelectPhoto.Attributes.Add("data-target", "#album");
        }
