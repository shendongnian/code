    Chunk c1 = new Chunk("Earth Pit.", FontFactory.GetFont(FontFactory.TIMES_BOLD, 10,iTextSharp.text.Font.UNDERLINE));
    Chunk c2 = new Chunk(" The existing earth...", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10));
    ListItem li = new ListItem("", FontFactory.GetFont(TIMES_ROMAN, 10));
    p.Add(c1);
    p.Add(c2);
    lst_terms.Add(li);
