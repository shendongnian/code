     for (int i = 0; i < parallelLines.Count; i++)
     {
            var pair = new List<IntersectionType>();
            for (int j = 0; j < polyLines.Count; j++)
            {
                var actual = ber.LineSegementsIntersect(
                    parallelLines[i].v1,
                    parallelLines[i].v2,
                    polyLines[j].v1,
                    polyLines[j].v2,
                    out intersection);
                // if intersection is found
                if (actual) pair .Add(intersection);                    
            }
            intersections.Add(pair.OrderBy(I=i.XValue).First());
            intersections.Add(pair.OrderByDescending(I=i.XValue).First());
     }
