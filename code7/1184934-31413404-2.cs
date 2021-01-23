     var xml = "<MyObjectBuilder_EntityBase>" +
            "<EntityId>173933426524952854</EntityId>" +
            "<PersistentFlags>CastShadows InScene</PersistentFlags>" +
            "<PositionAndOrientation>" +
            "<Position x=\"32.206989288330078\" y=\"28.401615142822266\" z=\"11.562240600585937\" />" +
            "<Forward x=\"0.323335081\" y=\"-0.00425125659\" z=\"-0.946275\" />" +
            "<Up x=\"-0.9462663\" y=\"-0.007667198\" z=\"-0.32329765\" />" +
            "</PositionAndOrientation>" +
            "<GridSizeEnum>Small</GridSizeEnum>" +
            "<CubeBlocks>" +
            "<MyObjectBuilder_CubeBlock>" +
            "<SubtypeName>Weight</SubtypeName>" +
            "<EntityId>173933426524952855</EntityId>" +
            "<Min x=\"0\" y=\"0\" z=\"0\" />" +
            "<BlockOrientation Forward=\"Forward\" Up=\"Up\" />" +
            "<ColorMaskHSV x=\"0\" y=\"-1\" z=\"0\" />" +
            "<ShareMode>None</ShareMode>" +
            "<DeformationRatio>0</DeformationRatio>" +
            "</MyObjectBuilder_CubeBlock>" +
            "</CubeBlocks>" +
            "<IsStatic>false</IsStatic>" +
            "<Skeleton />" +
            "<LinearVelocity x=\"0\" y=\"0\" z=\"0\" />" +
            "<AngularVelocity x=\"0\" y=\"0\" z=\"0\" />" +
            "<XMirroxPlane />" +
            "<YMirroxPlane />" +
            "<ZMirroxPlane />" +
            "<BlockGroups />" +
            "<Handbrake>false</Handbrake>" +
            "<DisplayName>Grid 2854</DisplayName>" +
            "<DestructibleBlocks>true</DestructibleBlocks>" +
            "<CreatePhysics>true</CreatePhysics>" +
            "<EnableSmallToLargeConnections>true</EnableSmallToLargeConnections>" +
            "</MyObjectBuilder_EntityBase>";
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var xlist = new List<string>();
            var ylist = new List<string>();
            var zlist = new List<string>();
            var subtypeName = doc.SelectSingleNode("//SubtypeName");
            if (subtypeName.InnerText == "Weight")
            {
                var position = doc.SelectSingleNode("//Position");
                xlist.Add(position.Attributes["x"].Value);
                ylist.Add(position.Attributes["y"].Value);
                zlist.Add(position.Attributes["z"].Value);
            }
