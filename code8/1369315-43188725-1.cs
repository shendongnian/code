    public partial class MainWindow : Window {
    
            TransformManyBlock<string, string> dirToFilesBlock;
            ActionBlock<string> fileActionBlock;
            ObservableCollection<string> files;
            CancellationTokenSource cts;
            CancellationToken ct;
            public MainWindow() {
                InitializeComponent();
    
                files = new ObservableCollection<string>();
    
                lst.DataContext = files;
    
                cts = new CancellationTokenSource();
                ct = cts.Token;
            }
    
            private async Task Start(string path) {
                var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    
                dirToFilesBlock = new TransformManyBlock<string, string>((Func<string, IEnumerable<string>>)(GetFileSystemItems), new ExecutionDataflowBlockOptions() { CancellationToken = ct });
                fileActionBlock = new ActionBlock<string>((Action<string>)ProcessFile, new ExecutionDataflowBlockOptions() { CancellationToken = ct, TaskScheduler = uiScheduler });
    
                // Order of LinkTo's important here!
                dirToFilesBlock.LinkTo(dirToFilesBlock, new DataflowLinkOptions() { PropagateCompletion = true }, IsDirectory);
                dirToFilesBlock.LinkTo(fileActionBlock, new DataflowLinkOptions() { PropagateCompletion = true }, IsRequiredDocType);
    
                // Kick off the recursion.
                dirToFilesBlock.Post(path);
    
                await ProcessingIsComplete();
                dirToFilesBlock.Complete();
                await Task.WhenAll(dirToFilesBlock.Completion, fileActionBlock.Completion);
            }
    
            private async Task ProcessingIsComplete() {
                while (!ct.IsCancellationRequested && DirectoryToFilesBlockIsIdle()) {
                    await Task.Delay(500);
                }
            }
    
            private bool DirectoryToFilesBlockIsIdle() {
                return dirToFilesBlock.InputCount == 0 &&
                    dirToFilesBlock.OutputCount == 0 &&
                    directoriesBeingProcessed <= 0;
            }
    
            private bool IsDirectory(string path) {
                return Directory.Exists(path);
            }
    
    
            private bool IsRequiredDocType(string fileName) {
                return System.IO.Path.GetExtension(fileName) == ".xlsx";
            }
    
            private int directoriesBeingProcessed = 0;
    
            private IEnumerable<string> GetFilesInDirectory(string path) {
                Interlocked.Increment(ref directoriesBeingProcessed)
                // Check for cancellation with each new dir.
                ct.ThrowIfCancellationRequested();
    
                // Check in case of Dir access problems
                try {
                    return Directory.EnumerateFileSystemEntries(path);
                } catch (Exception) {
                    return Enumerable.Empty<string>();
                } finally {
                    Interlocked.Decrement(ref directoriesBeingProcessed);
                }
            }
    
            private IEnumerable<string> GetFileSystemItems(string dir) {
                return GetFilesInDirectory(dir);
            }
    
            private void ProcessFile(string fileName) {
                ct.ThrowIfCancellationRequested();
    
                files.Add(fileName);
            }
    
            private async void btnStart_Click(object sender, RoutedEventArgs e) {
                try {
                    await Start(@"C:\");
                    // Never gets here!!!
                    MessageBox.Show("Completed");
    
                } catch (OperationCanceledException) {
                    MessageBox.Show("Cancelled");
    
                } catch (Exception) {
                    MessageBox.Show("Unknown err");
                } finally {
                }
            }
    
            private void btnCancel_Click(object sender, RoutedEventArgs e) {
                cts.Cancel();
            }
        }
