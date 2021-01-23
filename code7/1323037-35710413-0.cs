    using Google.Apis.Auth.OAuth2; 
    using Google.Apis.Services;
    using Google.Apis.Dataproc.v1; 
    using Google.Apis.Dataproc.v1.Data;
    using System; 
    using System.Threading;
    namespace DataprocSample {
        class Program
        {
            static void Main(string[] args)
            {
                string project = "YOUR PROJECT HERE";
                string dataprocGlobalRegion = "global";
                string zone = "us-east1-b";
                string machineType = "n1-standard-4";
                string clusterName = "sample-cluster";
                int numWorkers = 2;
                // See the docs for Application Default Credentials:
                // https://developers.google.com/identity/protocols/application-default-credentials
                // In general, a previous 'gcloud auth login' will suffice if running as yourself.
                // If running from a VM, ensure the VM was started such that the service account has
                // the CLOUD_PLATFORM scope. 
                GoogleCredential credential = GoogleCredential.GetApplicationDefaultAsync().Result;
                if (credential.IsCreateScopedRequired)
                {
                    credential = credential.CreateScoped(new[] { DataprocService.Scope.CloudPlatform });
                }
                DataprocService service = new DataprocService(
                    new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Dataproc Sample",
                    });
                // Create a new cluster:
                Cluster newCluster = new Cluster
                {
                    ClusterName = clusterName,
                    Config = new ClusterConfig
                    {
                        GceClusterConfig = new GceClusterConfig
                        {
                            ZoneUri = String.Format(
                                "https://www.googleapis.com/compute/v1/projects/{0}/zones/{1}",
                                project, zone),
                        },
                        MasterConfig = new InstanceGroupConfig
                        {
                            NumInstances = 1,
                            MachineTypeUri = String.Format(
                                "https://www.googleapis.com/compute/v1/projects/{0}/zones/{1}/machineTypes/{2}",
                                project, zone, machineType),
                        },
                        WorkerConfig = new InstanceGroupConfig
                        {
                            NumInstances = numWorkers,
                            MachineTypeUri = String.Format(
                                "https://www.googleapis.com/compute/v1/projects/{0}/zones/{1}/machineTypes/{2}",
                                project, zone, machineType),
                        },
                    },
                };
                Operation createOperation = 
                    service.Projects.Regions.Clusters.Create(newCluster, project, dataprocGlobalRegion).Execute();
                // Poll the operation:
                while (!IsDone(createOperation))
                {
                    Console.WriteLine("Polling operation {0}", createOperation.Name);
                    createOperation =
                        service.Projects.Regions.Operations.Get(createOperation.Name).Execute();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Done creating cluster {0}", newCluster.ClusterName);
            }
            static bool IsDone(Operation op)
            {
                return op.Done ?? false;
            }
        }
     }
