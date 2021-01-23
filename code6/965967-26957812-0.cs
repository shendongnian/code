        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Data.SqlClient;
        using System.Windows;
        using Infragistics.Controls.Maps;
        using Microsoft.SqlServer.Types;
        namespace TestMVVMLightProject.Model
        {
            public class SqlGeometryToShapeConverter : ObservableCollection<ShapefileRecord>
            {
                public SqlGeometryToShapeConverter()
                {
                    //connect
                    //load sql
                    //go thorugh points
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "localhost";
                    builder.InitialCatalog = "RefDB_91_DistToCoast";
                    builder.IntegratedSecurity = true;
                    SqlConnection conn = new SqlConnection(builder.ConnectionString);
                    conn.Open();
                    string sql = "SELECT huc_2, geom FROM Polygon2";
                    using (SqlCommand oCmd = new SqlCommand(sql, conn))
                    {
                        oCmd.CommandTimeout = 3000;
                        using (SqlDataReader oDr = oCmd.ExecuteReader())
                        {
                            int ordGeom = oDr.GetOrdinal("geom");
                            int ordHucZone = oDr.GetOrdinal("huc_2");
                            double minX = double.MaxValue;
                            double minY = double.MaxValue;
                            double maxX = double.MinValue;
                            double maxY = double.MinValue;
                            while (oDr.Read())
                            {
                                var rec = new ShapefileRecord();
                                rec.Points = new List<List<Point>>();
                        
                                SqlGeography coast = (SqlGeography)oDr.GetValue(ordGeom);
                                int numPolygons = (int)coast.STNumGeometries();
                                string hucZone = oDr.GetString(ordHucZone);
                                int hucInt = int.Parse(hucZone);
                                for (int geomIndex = 1; geomIndex <= coast.STNumGeometries(); geomIndex++)
                                {
                                    SqlGeography polygon = coast.STGeometryN(geomIndex);
                                    var points = new List<Point>();
                                    for (int verticeIndex = 1; verticeIndex <= polygon.STNumPoints(); verticeIndex++)
                                    {
                                        points.Add(new Point(polygon.STPointN(verticeIndex).Long.Value, polygon.STPointN(verticeIndex).Lat.Value));
                                        if (hucInt < 19)
                                        {
                                            minX = minX < polygon.STPointN(verticeIndex).Long.Value ? minX : polygon.STPointN(verticeIndex).Long.Value;
                                            minY = minY < polygon.STPointN(verticeIndex).Lat.Value ? minY : polygon.STPointN(verticeIndex).Lat.Value;
                                            maxX = maxX > polygon.STPointN(verticeIndex).Long.Value ? maxX : polygon.STPointN(verticeIndex).Long.Value;
                                            maxY = maxY > polygon.STPointN(verticeIndex).Lat.Value ? maxY : polygon.STPointN(verticeIndex).Lat.Value;
                                        }
                                    }
                            
                                    rec.Points.Add(points);
                                }
                                
                                rec.Fields = new ShapefileRecordFields { { "HUC_2", hucZone.ToString() } };
                                this.Add(rec);
                            }
                            worldRect = new Rect(new Point(minX, minY), new Point(maxX, maxY));
                        }
                    }
                    conn.Close();
                }
                private Rect worldRect; 
                public Rect WorldRect
                {
                    get
                    {
                        return worldRect;        
                    }
                }
            }
        }
       
