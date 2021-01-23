                    int NoteCounter = 0;
                    int MaxNotes = 100;
                    string SongSegment = "";
                    Random NoteIndexGen = new Random();
                    while (NoteCounter <= MaxNotes)
                    {
                        int NoteIndex = NoteIndexGen.Next(1, 7);
                        #region SetNotes
                        switch (Key)
                        {
                            case "C-Maj":
                                switch (NoteIndex)
                                {
                                    case 1:
                                        SongSegment += "  C  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 2:
                                        SongSegment += "  D  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 3:
                                        SongSegment += "  E  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 4:
                                        SongSegment += "  F  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 5:
                                        SongSegment += "  G  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 6:
                                        SongSegment += "  A  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 7:
                                        SongSegment += "  B  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                }
                                break;
                            case "G-Mag":
                                switch (NoteIndex)
                                {
                                    case 1:
                                        SongSegment += "  G  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 2:
                                        SongSegment += "  A  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 3:
                                        SongSegment += "  B  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 4:
                                        SongSegment += "  C  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 5:
                                        SongSegment += "  D  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 6:
                                        SongSegment += "  E  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 7:
                                        SongSegment += "  F#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                }
                                break;
                            case "D-Maj":
                                switch (NoteIndex)
                                {
                                    case 1:
                                        SongSegment += "  D  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 2:
                                        SongSegment += "  E  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 3:
                                        SongSegment += "  F#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 4:
                                        SongSegment += "  G  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 5:
                                        SongSegment += "  A  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 6:
                                        SongSegment += "  B  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 7:
                                        SongSegment += "  C#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                }
                                break;
                            case "A-Maj":
                                switch (NoteIndex)
                                {
                                    case 1:
                                        SongSegment += "  A  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 2:
                                        SongSegment += "  B  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 3:
                                        SongSegment += "  C#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 4:
                                        SongSegment += "  D  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 5:
                                        SongSegment += "  E  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 6:
                                        SongSegment += "  F#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 7:
                                        SongSegment += "  G#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                }
                                break;
                            case "E-Maj":
                                switch (NoteIndex)
                                {
                                    case 1:
                                        SongSegment += "  E  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 2:
                                        SongSegment += "  F#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 3:
                                        SongSegment += "  G#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 4:
                                        SongSegment += "  A  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 5:
                                        SongSegment += "  B  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 6:
                                        SongSegment += "  C#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                    case 7:
                                        SongSegment += "  D#  ";
                                        OutputInfo1.Text = SongSegment;
                                        break;
                                }
                                break;
                        }
                        NoteCounter++;
                        #endregion SetNotes
                        #endregion GenerateMusic
                    }
