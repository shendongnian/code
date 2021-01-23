                Font bFont = new Font("Calibri", defFontSize, FontStyle.Bold);       // Bold font
                Font iFont = new Font("Calibri", defFontSize, FontStyle.Italic);     // Italic font
                Font nFont = new Font("Calibri", defFontSize);                       // Normal font
                DataGridViewCellStyle dgvcsOKRESULT = new DataGridViewCellStyle()
                {
                    Font = nFont,
                    ForeColor = Color.White,
                    BackColor = Color.Green,
                };
                DataGridViewCellStyle dgvcsBADRESULT = new DataGridViewCellStyle()
                {
                    Font = bFont,
                    ForeColor = Color.White,
                    BackColor = Color.Red,
                };
