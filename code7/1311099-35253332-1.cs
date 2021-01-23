    var result = dept.Projects
                    .Cast<Project>()
                    .Where(
                        project =>
                            project.State == pState.state_initiated &&
                            project.Properties().Any(property => property.Name == "InitiatorName"));
