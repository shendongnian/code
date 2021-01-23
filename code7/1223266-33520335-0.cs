                        //Appened new note to existing note.
                          existingSlideNote =         slidePart2.NotesSlidePart.NotesSlide.InnerText + "\n";
                        var val = slidePart2.NotesSlidePart;
                        notesSlidePart1 = slidePart2.AddPart<NotesSlidePart>(val);
                    }
                    else
                    {  
                        //Add a new noteto a slide.                      
                        notesSlidePart1 = slidePart2.AddNewPart<NotesSlidePart>(relId);
                    }
