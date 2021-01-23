            private void ViewPort3D_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
    
                Ray ray = this.ViewPort3D.UnProject(new Vector2((float)e.GetPosition(ViewPort3D).X, (float)e.GetPosition(ViewPort3D).Y));
                var hits = new List<HitTestResult>();
    
                // dictionary for connecting the id of the specific element and its distance
                var hitElements = new Dictionary<int, double>();
    
                // loop over all MeshGeometryModel3D elements
                foreach (var geometry in Geometrys)
                {
                    var isHit = geometry.Model3D.HitTest(ray, ref hits);
                    if (isHit)
                    {
                        hitElements.Add(geometry.Id, hits[hits.Count - 1].Distance);
                    }
                }
    
                if (hits.Count > 0)
                {
                    
                    double minDistance = hitElements.First().Value;
                    int id_of_hit_element = hitElements.First().Key;
    
                    foreach (var hit in hitElements)
                    {
                        if (hit.Value < minDistance)
                        {
                            minDistance = hit.Value;
                            id_of_hit_element = hit.Key;
                        }
                    }
    
                    var topElement = Geometrys.Find(geometry => geometry.Id == id_of_hit_element);
    
                    // do something with top element
                }
            }
