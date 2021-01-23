         string strCriteria =
         String.Format(@"<Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
              <Expression>
                <SimpleExpression>
                  <ValueExpressionLeft>
                    <Property>$Context/Path[Relationship='WorkItem!System.WorkItemAffectedUser' TypeConstraint='System!System.Domain.User']/Property[Type='System!System.Domain.User']/UserName$</Property>
                  </ValueExpressionLeft>
                     <Operator>Like</Operator>
                  <ValueExpressionRight>
                    <Value>%" + userName + @"%</Value>
                  </ValueExpressionRight>
                </SimpleExpression>
              </Expression>
            </Criteria>");
            ManagementPack workItemMp = emg.GetManagementPack("System.WorkItem.Incident.Library", "31bf3856ad364e35", new Version("7.5.3079.0"));  // Incident MP
            ManagementPack projMp = emg.GetManagementPack("ServiceManager.IncidentManagement.Library", "31bf3856ad364e35", new Version("7.5.3079.0")); // <-- MP where Type Projection lives
            ManagementPackTypeProjection workItemRelConfigProj = emg.EntityTypes.GetTypeProjection("System.WorkItem.Incident.ProjectionType", projMp); // <-- Type Projection Name
            ObjectProjectionCriteria projCriteria = new ObjectProjectionCriteria(strCriteria, workItemRelConfigProj, projMp, emg);
            IObjectProjectionReader<EnterpriseManagementObject> reader = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(projCriteria, ObjectQueryOptions.Default);
            if (reader != null && reader.Count > 0)
            {
                foreach (EnterpriseManagementObjectProjection obj in reader)
                {
                    //TO DO
                }
            }
