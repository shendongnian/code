        for (int i = 0; i < TeamList.Count; i++)
            {
                if (TeamList[i].Color == "RED")
                {
                    dg_teams.Rows.Add(TeamList[i].ID, TeamList[i].name, TeamList[i].Color, TeamList[i].productOwner, TeamList[i].scrumMaster);
                    dg_teams.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                }
                if (TeamList[i].Color == "GREEN")
                {
                    dg_teams.Rows.Add(TeamList[i].ID, TeamList[i].name, TeamList[i].Color, TeamList[i].productOwner, TeamList[i].scrumMaster);
                    dg_teams.Rows[i].Cells[2].Style.ForeColor = Color.Green;
                }
                if (TeamList[i].Color == "YELLOW")
                {
                    dg_teams.Rows.Add(TeamList[i].ID, TeamList[i].name, TeamList[i].Color, TeamList[i].productOwner, TeamList[i].scrumMaster);
                    dg_teams.Rows[i].Cells[2].Style.ForeColor = Color.Yellow;
                }
                if (TeamList[i].Color == "BLUE")
                {
                    dg_teams.Rows.Add(TeamList[i].ID, TeamList[i].name, TeamList[i].Color, TeamList[i].productOwner, TeamList[i].scrumMaster);
                    dg_teams.Rows[i].Cells[2].Style.ForeColor = Color.Blue;
                }
                if (TeamList[i].Color == "ORANGE")
                {
                    dg_teams.Rows.Add(TeamList[i].ID, TeamList[i].name, TeamList[i].Color, TeamList[i].productOwner, TeamList[i].scrumMaster);
                    dg_teams.Rows[i].Cells[2].Style.ForeColor = Color.Orange;
                }
