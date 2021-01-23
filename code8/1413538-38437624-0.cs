            string ns = "reservation.fidelio.2.0";
            string node = "HotelReference";
            string elem = "hotelCode";
            XName xn = XName.Get(node, ns);
            XName xe = XName.Get(elem, ns);
            var HotelReference = doc.Root.Descendants(xn).Select(x => new { HotelCode = x.Element(xe).Value }).FirstOrDefault();
