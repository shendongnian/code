     class GeneralFormHelper
        {
            GeneralForm generalform2;
            public void GetGeneralForm(GeneralForm g)
            {
              this.generalform2 = g;
            }
            public void LoadConfig()
            {
              this.generalform2.txtDSN1.Text = "test";
            }
        }
