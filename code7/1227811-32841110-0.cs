                List<LEGAL_MEMBER> _LegalMemberList = _dc.LEGAL_MEMBERs.Where(a => a.IDNumber == txtIDNumber.Text.ToString()).ToList();
                if (rbtnAreYouEmployed.Items[0].Selected == true)
                {
                    ViewState["AreyouEmployed"] = true;
                }
                else
                {
                    ViewState["AreyouEmployed"] = false;
                }
                if (rbtnIsSACitizen.Items[0].Selected == true)
                {
                    ViewState["IsSACitizen"] = true;
                }
                else
                {
                    ViewState["IsSACitizen"] = false;
                }
                if (_LegalMemberList != null)
                {
                    if (_LegalMemberList.Count() == 0)
                    {
                        LEGAL_MEMBER _legalMember = new LEGAL_MEMBER
                        {
                            IDNumber = txtIDNumber.Text,
                            InceptionDate = Convert.ToDateTime(txtInceptionDate.Text),
                            LegalPreferedName = txtPreferedName.Text,
                            Initials = txtInitials.Text,
                            TitleID = int.Parse(cboTitle.SelectedValue),
                            FullNames = txtFullNames.Text,
                            Surname = txtSurname.Text,
                            Age = int.Parse(txtAge.Text),
                            DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                            PassportNumber = txtPassport.Text,
                            AreyouEmployed = bool.Parse(ViewState["AreyouEmployed"].ToString()),
                            Employer = txtEmployer.Text,
                            ContactNumber = txtContactNumber.Text,
                            OtherContanctNumber = txtOtherContanctNumber.Text,
                            EmailAddress = txtEmailAddress.Text,
                            IsSACitizen = bool.Parse(ViewState["IsSACitizen"].ToString()),
                            TelephoneWork = txtTelephoneWork.Text,
                            TelephoneHome = txtTelephoneHome.Text,
                        };
             
                        _dc.LEGAL_MEMBERs.InsertOnSubmit(_legalMember);
                        _dc.SubmitChanges();
