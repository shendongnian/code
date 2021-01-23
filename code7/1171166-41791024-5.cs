C#
/// <summary>
/// Casts the result type of the input task as if it were covariant
/// </summary>
/// <typeparam name="T">The original result type of the task</typeparam>
/// <typeparam name="TResult">The covariant type to return</typeparam>
/// <param name="task">The target task to cast</param>
[MethodImpl(MethodImplOptions.AggressiveInlining)]
public static async Task<TResult> AsTask<T, TResult>(this Task<T> task) 
    where T : TResult 
    where TResult : class
{
    return await task;
}
This way you can just do:
C#
class ResultBase {}
class Result : ResultBase {}
Task<Result> GetResultAsync() => ...; // Some async code that returns Result
Task<ResultBase> GetResultBaseAsync() 
{
    return GetResultAsync().AsTask<Result, ResultBase>();
}
