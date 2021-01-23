     for (int i = 0; i < parallelLines.Count; i++)
     {
            var pair = new List<IntersectionType>();
            for (int j = 0; j < polyLines.Count; j++)
                if(ber.LineSegementsIntersect(
                     parallelLines[i].v1, parallelLines[i].v2,
                     polyLines[j].v1, polyLines[j].v2,
                     out intersection))
                   pair .Add(intersection);
            intersections.Add(pair.OrderBy(i=>i.XValue).First());
            intersections.Add(pair.OrderByDescending(i=>i.XValue).First());
     }
