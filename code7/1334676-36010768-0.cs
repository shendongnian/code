    var lstgroupCode = (from g in _context.ALM_USER_GROUP_MSTs where g.isShiftAvailable == true select g.User_Group_Code).ToList();
    
                foreach (var item in lstgroupCode)
                {
                    if (item == UserGroupCode)
                    {
                        btnPlaySuspend.Visible = true;
                        lblPlayPause.Visible = true;
                        btnStopSuspend.Visible = true;
                        lblStop.Visible = true;
                    }
                    else
                    {
                        btnPlaySuspend.Visible = false;
                        lblPlayPause.Visible = false;
                        btnStopSuspend.Visible = false;
                        lblStop.Visible = false;
                    }
                }
